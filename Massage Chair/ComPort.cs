using System;
using System.IO;
using System.IO.Ports;
using System.Collections;
using System.Windows.Forms;
using System.Threading;

namespace Massage_Chair
{
    public sealed class ComPort
    {
        /// <summary> ComPort class creates a singleton instance
        /// of SerialPort (System.IO.Ports) </summary>
        /// <remarks> When ready, you open the port.
        ///   <code>
        ///   ComPort com = ComPort.Instance;
        ///   com.StatusChanged += OnStatusChanged;
        ///   com.DataReceived += OnDataReceived;
        ///   com.Open();
        ///   </code>

        ///   Notice that delegates are used to handle status and data events.
        ///   When settings are changed, you close and reopen the port.
        ///   <code>
        ///   ComPort com = ComPort.Instance;
        ///   com.Close();
        ///   com.PortName = "COM4";
        ///   com.Open();
        ///   </code>
        /// </remarks>
        SerialPort _serialPort;
        Thread _readThread;
        volatile bool _keepReading;
        int _recvCount = 0;

        #region singleton
        //begin Singleton pattern
        //private static readonly ComPort instance = new ComPort();
        //고정된 메모리 영역을 얻으면서, 한 번의 new 인스턴스를 사용하기 때문에 메모리 낭비를 방지할 수 있음
        //싱글톤으로 만들어진 클래스의 인스턴스는 전역 인스턴스이기 때문에, 다른 클래스의 인스턴스들이 데이터를 공유하기 쉽다.
        private static readonly ComPort instance = null;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static ComPort()
        {
            if (instance == null)
            {
                instance = new ComPort();
            }
        }
        
        public ComPort()
        {
            _serialPort = new SerialPort();
            _serialPort.ReadBufferSize = 1024;
            _readThread = null;
            _keepReading = false;
        }

        public static ComPort Instance
        {
            get
            {
                return instance;
            }
        }
        //end Singleton pattern
        #endregion

        //begin Observer pattern
        //델리게이트 선언과 참조
        //1. 델리게이트로 특정 메소드(함수)를 호출하기 위해서, 특정 메소드와 동일한 타입의 델리게이트를 선언해야한다.
        //(ex)delegate 반환타입 델리게이트이름(매개변수);
        //2. 선언한 델리게이트 타입으로 델리게이트 변수를 생성하고,
        //3. 생성한 델리게이트 변수에 특정 메소드를 참조시킨다.(이 소스상에서는 form1에서 델리게이트 변수에 특정메소드를 참조함)
        //   ex>com.StatusChanged += OnStatusChanged;
        //   ex>com.DataReceived += OnDataReceived;

        public delegate void SerialEventDelegate<T>(T param);               //1.(일반화된)델리게이트 선언
        public SerialEventDelegate<string> StatusChanged;                   //2.델리게이트 변수 생성
        public SerialEventDelegate<string> DataReceived;                    //2.델리게이트 변수 생성
        //end Observer pattern

        public void DiscardInBuffer()
        {
            _serialPort.DiscardInBuffer();
        }

        private  void StartReading()
        {
            if (!_keepReading)
            {
                _keepReading = true;
                _readThread = new Thread(ReadPort);
                _readThread.Start();
            }
        }

        private void StopReading()
        {
            if (_keepReading)
            {
                _keepReading = false;
                _readThread.Join(); //block until exits
                _readThread = null;
            }
        }

        /// <summary> Get the data and pass it on. </summary>
        private void ReadPort()
        {
            byte[] readBuffer = new byte[_serialPort.ReadBufferSize];
 
            while (_keepReading)
            {
                if (_serialPort.IsOpen)
                {
                    try
                    {
                        // If there are bytes available on the serial port,
                        // Read returns up to "count" bytes, but will not block (wait)
                        // for the remaining bytes. If there are no bytes available
                        // on the serial port, Read will block until at least one byte
                        // is available on the port, up until the ReadTimeout milliseconds
                        // have elapsed, at which time a TimeoutException will be thrown.
                        _recvCount = _serialPort.Read(readBuffer, 0, _serialPort.ReadBufferSize);
                        //_recvCount = _serialPort.Read(readBuffer, 0, 1);

                        //String SerialIn = System.Text.Encoding.Default.GetString(readBuffer, 0, _recvCount);
                        string SerialIn = System.Text.Encoding.UTF7.GetString(readBuffer, 0, _recvCount);

                        DataReceived(SerialIn);
                    }
                    catch (TimeoutException) { }
                }
                else
                {
                    TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, 50);
                    Thread.Sleep(waitTime);
                }
            }
        }

        private static void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();

            //sp.DiscardInBuffer();
        }

        /// <summary> Open the serial port with current settings. </summary>
        public void Open()
        {
            //Close();
            //MessageBox.Show("연결버튼이 눌렸습니다.");
            try
            {
                //MessageBox.Show("시리얼 포트 연결을 시작합니다.");

                _serialPort.PortName = ComSetting.Port.PortName;
                _serialPort.BaudRate = ComSetting.Port.BaudRate;
                _serialPort.Parity = ComSetting.Port.Parity;
                _serialPort.DataBits = ComSetting.Port.DataBits;
                _serialPort.StopBits = ComSetting.Port.StopBits;
                _serialPort.Handshake = ComSetting.Port.Handshake;

                // Set the read/write timeouts
                _serialPort.ReadTimeout = 50;
                _serialPort.WriteTimeout = 50;

                _serialPort.Open();
                // _serialPort.Open
                // 요약:
                //     새 직렬 포트 연결을 엽니다.
                //
                // 예외:
                //   T:System.UnauthorizedAccessException:
                //     포트에 액세스할 수 없습니다. 또는 지정된 된 COM 포트를 열에 이미 현재 프로세스 또는 시스템에서 다른 프로세스는 System.IO.Ports.SerialPort
                //     인스턴스 또는 관리 되지 않는 코드입니다.
                //
                //   T:System.ArgumentOutOfRangeException:
                //     이 인스턴스에 대 한 속성 중 하나 이상이 올바르지 않습니다. 예를 들어는 System.IO.Ports.SerialPort.Parity,
                //     System.IO.Ports.SerialPort.DataBits, 또는 System.IO.Ports.SerialPort.Handshake
                //     속성이 잘못 된 값 이며, System.IO.Ports.SerialPort.BaudRate 보다 작거나 같으면 0;는 System.IO.Ports.SerialPort.ReadTimeout
                //     또는 System.IO.Ports.SerialPort.WriteTimeout 속성 보다 작은 0 이며 아닌 경우 System.IO.Ports.SerialPort.InfiniteTimeout합니다.
                //
                //   T:System.ArgumentException:
                //     포트 이름을 "COM"으로 시작 되지 않습니다. 또는 포트의 파일 형식이 지원 되지 않습니다.
                //
                //   T:System.IO.IOException:
                //     포트가 잘못 된 상태입니다. 또는 기본 포트의 상태를 설정 하지 못했습니다. 이 매개 변수가 전달 되는 예를 들어 System.IO.Ports.SerialPort
                //     개체가 잘못 되었습니다.
                //
                //   T:System.InvalidOperationException:
                //     현재 인스턴스에서 지정된 된 포트는 System.IO.Ports.SerialPort 가 이미 열려 있습니다
                StartReading();
            }
            catch (UnauthorizedAccessException)
            {
                StatusChanged(String.Format("{0} already in use", _serialPort.PortName));
            }
            catch (IOException)
            {
                StatusChanged(String.Format("{0} does not exist", _serialPort.PortName));
            }
            catch (Exception ex)
            {
                StatusChanged(String.Format("{0}", ex.ToString()));
            }

            // Update the status
            if (_serialPort.IsOpen)
            {
                string p = _serialPort.Parity.ToString().Substring(0, 1);   //First char
                string h = _serialPort.Handshake.ToString();

                if (_serialPort.Handshake == Handshake.None)
                    h = "no handshake"; // more descriptive than "None"

                StatusChanged(String.Format("{0}: {1} bps, {2}{3}{4}, {5}",
                    _serialPort.PortName, _serialPort.BaudRate,
                    _serialPort.DataBits, p, (int)_serialPort.StopBits, h));
            }
            else
            {
                StatusChanged(String.Format("{0} already in use", ComSetting.Port.PortName));
            }
        }

        /// <summary> Close the serial port. </summary>
        public void Close()
        {
            StopReading();
            _serialPort.Close();
            StatusChanged("connection closed");
        }

        /// <summary> Get the status of the serial port. </summary>
        public bool IsOpen
        {
            get
            {
                return _serialPort.IsOpen;
            }
        }

        /// <summary> Get a list of the available ports. Already opened ports
        /// are not returend. </summary>
        public string[] GetAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>Send data to the serial port after appending line ending. </summary>
        /// <param name="data">An string containing the data to send. </param>
        public void Send(string data)
        {
            if (IsOpen)
            {
                string lineEnding = "";

                switch (ComSetting.Option.AppendToSend)
                {
                    case ComSetting.Option.AppendType.AppendCR:
                        lineEnding = "\r"; break;
                    case ComSetting.Option.AppendType.AppendLF:
                        lineEnding = "\n"; break;
                    case ComSetting.Option.AppendType.AppendCRLF:
                        lineEnding = "\r\n"; break;
                }
                _serialPort.Write(data + lineEnding);
            }
        }

        public void Send(byte[] byteSendData, Int32 offset, int count)
        {
            _serialPort.Write(byteSendData, offset, count);
        }
    }
}
