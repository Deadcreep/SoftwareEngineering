namespace Patterns.Ex00
{
    public class LogImporterClient
    {
        /// <summary>
        /// TODO: Изменения нужно вносить в этом методе
        /// </summary>
        public void DoMethod(ILogReader reader)
        {
            LogImporter importer = new LogImporter(reader);
            importer.ImportLogs("ftp://log.txt");
        }

    }
}