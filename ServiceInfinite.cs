using System;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using System.Threading;
namespace VerificarXE
{
	class Program
	{
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		const int SW_HIDE = 0;		
		
		public static void Main(string[] args)
		{
			
			ShowWindow(GetConsoleWindow(), SW_HIDE);
			
						
			while (true) {
					
				try {
					var sc = new ServiceController("OracleServiceXE");
				
				
					if ((sc.Status.Equals(ServiceControllerStatus.Stopped)) ||
					     (sc.Status.Equals(ServiceControllerStatus.StopPending))) {			   			
					 
						sc.Start();
					}  
								
					sc.Refresh();		
					
				} catch(Exception ex) {
				}
				
				
				Thread.Sleep(1000);
			
			}
			
			
		}
	}
}
