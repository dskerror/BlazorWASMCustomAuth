﻿using System;
using System.Collections.Generic;

namespace BlazorWASMCustomAuth.Security.Shared;

public partial class ApplicationLoginRequestDto
{
    public string ApplicationAuthenticationProviderGuid { get; set; }

    public string AppApiKey { get; set; }
}
