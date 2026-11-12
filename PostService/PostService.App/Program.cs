using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace PostService.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => HandleGlobalException(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                if (e.ExceptionObject is Exception ex) HandleGlobalException(ex);
            };

            ApplicationConfiguration.Initialize();
            Application.Run(new PostingList());
        }

        private static void HandleGlobalException(Exception ex)
        {
            Debug.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex.GetType().FullName}: {ex.Message}\n{ex.StackTrace}");
            MessageBox.Show(
                "Виникла непередбачена помилка під час роботи застосунку. Спробуйте повторити дію пізніше.",
                "Помилка програми",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}