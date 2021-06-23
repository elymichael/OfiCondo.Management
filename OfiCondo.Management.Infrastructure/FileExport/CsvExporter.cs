namespace OfiCondo.Management.Infrastructure.FileExport
{
    using CsvHelper;
    using OfiCondo.Management.Application.Contracts.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class CsvExporter: ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<Object> eventExportDtos)
        {
            var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.InvariantCulture, false);
                csvWriter.WriteRecord(eventExportDtos);

            }

            return memoryStream.ToArray();
        }
    }
}
