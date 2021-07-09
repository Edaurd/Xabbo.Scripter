﻿using System;

namespace b7.Scripter.Scripting
{
    public enum ScriptStatus
    {
        None,
        // Errors
        UnknownError,
        FileNotFound,
        CompileError,
        RuntimeError,
        TimedOut,
        Aborted,
        // Warnings
        // Modified,
        // State
        Compiling,
        Executing,
        Cancelling,
        Canceled,
        Complete
    }
}
