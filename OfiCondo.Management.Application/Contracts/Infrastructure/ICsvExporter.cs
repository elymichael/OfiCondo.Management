namespace OfiCondo.Management.Application.Contracts.Infrastructure
{
    using System;
    using System.Collections.Generic;
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<Object> eventExportDtos);
    }
}
