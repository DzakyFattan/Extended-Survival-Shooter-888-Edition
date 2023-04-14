using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public enum LoadedFrom
    {
        Any,
        End
    }
    public static LoadedFrom loadedFrom = LoadedFrom.Any;
}
