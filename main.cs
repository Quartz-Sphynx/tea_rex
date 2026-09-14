using System;
using System.Drawing;
using System.Windows.Forms; // Pulls from the native Windows framework

namespace mainTeaRex
{
    class Program
    {
        [STAThread] // 🟢 MANDATORY: Directs Windows to handle this as a native UI layout thread
        public static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("       TEA_REX MAIN UTILITY INTERFACE         ");
            Console.WriteLine("==============================================");

            // 1. Run your core security sandbox routines
            Console.WriteLine("\n[CORE]: Initializing secure sandbox layer...");
            string sandboxTestScript = """
                using System;
                public class UserScript {
                    public static void Run() {
                        Console.WriteLine(">>> [SANDBOX]: Verification payload active and running safely.");
                    }
                }
                """;
            BlockSandbox.ExecuteSafeCode(sandboxTestScript); 

            Console.WriteLine("\n[CORE]: Handing control off to UI window engine...");

            // 2. Build the window container using native Win32 controls
            Form window = new Form
            {
                Text = "Tea_Rex Application Monitor",
                Width = 900,
                Height = 650,
                BackColor = Color.FromArgb(12, 12, 14), 
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.Sizable 
            };

            // 3. Inject your clean monospace greeting text control
            Label textLabel = new Label
            {
                Text = "Hello Tea_Rex\n\nCore Subsystems: Operational",
                ForeColor = Color.FromArgb(57, 255, 20), 
                Font = new Font("Consolas", 24, FontStyle.Bold), 
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            window.Controls.Add(textLabel);

            // 4. Start the native window layout loop
            Application.Run(window);

            Console.WriteLine("\n[CORE]: Main program loop closed gracefully.");
        }
    }
}
