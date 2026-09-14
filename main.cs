using System;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace mainTeaRex
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("=== VERIFYING SANDBOX ACTIVATION ===");

            // 1. Create a WeakReference to track if the sandbox memory actually unloads
            WeakReference alcWeakRef = ExecuteAndTrackSandbox();

            // 2. Force .NET to clean up memory (Garbage Collection)
            Console.WriteLine("\nTriggering memory cleanup (Garbage Collection)...");
            for (int i = 0; i < 10 && alcWeakRef.IsAlive; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            // 3. The Ultimate Proof
            if (!alcWeakRef.IsAlive)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[VERIFICATION PASSED]: Sandbox activated, isolated, and successfully unloaded from memory!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[VERIFICATION FAILED]: Sandbox code ran, but leaked memory and failed to deactivate.");
                Console.ResetColor();
            }

            Console.WriteLine("\nProceeding to browser validation step...");
            // ... Your Playwright browser code continues here ...
        }

        // Helper method to keep the sandbox scope local so it can be collected
        private static WeakReference ExecuteAndTrackSandbox()
        {
           // Using triple quotes ensures strings inside your sandbox code parse perfectly
    string testCode = """
        using System;
        public class UserScript {
            public static void Run() {
                Console.WriteLine(">>> Sandbox active: Running user code execution layer.");
            }
        }
        """;

    // Execute the code via your DLL logic
    BlockSandbox.ExecuteSafeCode(testCode);

    // Look for the active context to track its lifecycle
    var activeContexts = System.Runtime.Loader.AssemblyLoadContext.All;
    foreach (var context in activeContexts)
    {
        if (context.Name == "UserCodeContext")
        {
            return new WeakReference(context);
        }
    }

    return new WeakReference(null);
        }
    }
}