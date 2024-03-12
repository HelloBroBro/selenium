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

package org.openqa.selenium.bidi.storage;

import java.util.HashMap;
import java.util.Map;
import org.openqa.selenium.bidi.network.BytesValue;
import org.openqa.selenium.bidi.network.Cookie;

public class PartialCookie {
  private final Map<String, Object> map = new HashMap<>();

  public PartialCookie(String name, BytesValue value, String domain) {
    map.put("name", name);
    map.put("value", value);
    map.put("domain", domain);
  }

  public PartialCookie path(String path) {
    map.put("path", path);
    return this;
  }

  public PartialCookie size(long size) {
    map.put("size", size);
    return this;
  }

  public PartialCookie httpOnly(boolean httpOnly) {
    map.put("httpOnly", httpOnly);
    return this;
  }

  public PartialCookie secure(boolean secure) {
    map.put("secure", secure);
    return this;
  }

  public PartialCookie sameSite(Cookie.SameSite sameSite) {
    map.put("sameSite", sameSite.toString());
    return this;
  }

  public PartialCookie expiry(long expiry) {
    map.put("expiry", expiry);
    return this;
  }

  public Map<String, Object> toMap() {
    return map;
  }
}
