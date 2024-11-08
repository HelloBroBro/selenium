// <copyright file="RealmInfoConverter.cs" company="Selenium Committers">
// Licensed to the Software Freedom Conservancy (SFC) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The SFC licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.
// </copyright>

using OpenQA.Selenium.BiDi.Modules.Script;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable

namespace OpenQA.Selenium.BiDi.Communication.Json.Converters.Polymorphic;

// https://github.com/dotnet/runtime/issues/72604
internal class RealmInfoConverter : JsonConverter<RealmInfo>
{
    public override RealmInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonDocument = JsonDocument.ParseValue(ref reader);

        return jsonDocument.RootElement.GetProperty("type").ToString() switch
        {
            "window" => jsonDocument.Deserialize<RealmInfo.Window>(options),
            "dedicated-worker" => jsonDocument.Deserialize<RealmInfo.DedicatedWorker>(options),
            "shared-worker" => jsonDocument.Deserialize<RealmInfo.SharedWorker>(options),
            "service-worker" => jsonDocument.Deserialize<RealmInfo.ServiceWorker>(options),
            "worker" => jsonDocument.Deserialize<RealmInfo.Worker>(options),
            "paint-worklet" => jsonDocument.Deserialize<RealmInfo.PaintWorklet>(options),
            "audio-worklet" => jsonDocument.Deserialize<RealmInfo.AudioWorklet>(options),
            "worklet" => jsonDocument.Deserialize<RealmInfo.Worklet>(options),
            _ => null,
        };
    }

    public override void Write(Utf8JsonWriter writer, RealmInfo value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
