using System;
using System.Threading.Tasks;
using OpenWindow; // Your new window library DLL

namespace mainTeaRex
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("       TEA_REX MAIN UTILITY INTERFACE         ");
            Console.WriteLine("==============================================");

            // 1. YOUR SANDBOX GOES HERE 🟢
            // It compiles and executes security payloads before anything else starts
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


            // 2. Define the specific HTML look you want this project to display
            string teaRexLayout = """
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body { background: #0c0c0e; color: #39ff14; font-family: monospace; display: flex; justify-content: center; align-items: center; height: 100vh; margin: 0; }
                        .card { border: 1px dashed #39ff14; padding: 40px; border-radius: 4px; text-align: center; box-shadow: 0 0 20px rgba(57, 255, 20, 0.2); }
                        h1 { font-size: 3rem; margin: 0 0 10px 0; text-shadow: 0 0 10px #39ff14; }
                        p { color: #888; }
                    </style>
                </head>
                <body>
                    <div class="card">
                        <h1>Hello Tea_Rex</h1>
                        <p>Core Subsystems: Operational</p>
                    </div>
                </body>
                </html>
                """;

            // 3. YOUR REUSABLE WINDOW ENGINE LAUNCHES HERE 🟢
            // It automatically detects it is inside 'tea_rex', greets you, and fires the browser
            Console.WriteLine("\n[CORE]: Handing control off to UI window engine...");
            await WinOpen.LaunchAsync(
                htmlContent: teaRexLayout,
                windowTitle: "Tea_Rex Application Monitor"
            );

            Console.WriteLine("\n[CORE]: Main program loop closed gracefully.");
        }
    }
}
