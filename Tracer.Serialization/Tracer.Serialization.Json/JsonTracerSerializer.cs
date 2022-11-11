﻿using Tracer.Serialization.Abstractions;
using Tracer.Core;
using System.Text.Json;

namespace Tracer.Serialization.Json;

public class JsonTracerSerializer: ITraceResultSerializer
{
    public string Format { get; } = "undefined";

    public void Serialize(TraceResult traceResult, Stream to)
    {
        var jsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        JsonSerializer.Serialize(to, traceResult, jsonOptions);

    }
}
