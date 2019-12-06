﻿using System;

namespace WallApp.Engine.Services
{
    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
    sealed class ServiceReferenceAttribute : Attribute
    {
        public string Key { get; set; }
    }
}
