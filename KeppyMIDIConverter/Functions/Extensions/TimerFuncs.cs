using System;
using System.Runtime.InteropServices;

namespace KeppyMIDIConverter
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    struct LARGE_INTEGER
    {
        [FieldOffset(0)] public Int64 QuadPart;
        [FieldOffset(0)] public UInt32 LowPart;
        [FieldOffset(4)] public Int32 HighPart;
    }

    class TimerFuncs
    {
        delegate void TimerSetDelegate();
        delegate void TimerCompleteDelegate();

        [DllImport("ntdll.dll", CallingConvention = CallingConvention.StdCall)]
        static extern Int32 NtDelayExecution(Boolean dwAlertable, out LARGE_INTEGER dwDelayInterval);

        [DllImport("kernel32.dll")]
        static extern bool SetWaitableTimer(IntPtr hTimer, [In] ref LARGE_INTEGER ft, int lPeriod, TimerCompleteDelegate pfnCompletionRoutine, IntPtr pArgToCompletionRoutine, bool fResume);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern Int32 WaitForSingleObject(IntPtr Handle, uint Wait);

        [DllImport("kernel32.dll")]
        static extern bool CancelWaitableTimer(IntPtr hTimer);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        public static void MicroSleep(Int64 MicroSec)
        {
            LARGE_INTEGER ft = new LARGE_INTEGER() { QuadPart = MicroSec };
            NtDelayExecution(false, out ft);
        }
    }
}
