using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace PlayEyeData
{
    class GetEyeData
    {
        [DllImport("NidaqPlugin")]
        public static extern int reward(int on);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
	    public delegate void set_callback(IntPtr data);

	    [DllImport ("NidaqPlugin")]
	    private static extern int eog_set_callback (
	    [MarshalAs(UnmanagedType.FunctionPtr)]set_callback 
	    callbackPointer);
        
        static void Main()
        {
            Console.WriteLine("Hello World");
            Console.ReadLine();
            set_callback callback = 
                (data) =>
                    {
                        Console.WriteLine("Progress = {0}", data);
                    };
            eog_set_callback(callback);
        }
    }
}
