// Guids.cs
// MUST match guids.h
using System;

namespace Framework.FWCodeGenerator
{
    static class GuidList
    {
        public const string guidFWCodeGeneratorPkgString = "d3b3261a-d898-40eb-8c57-a315f72e6be6";
        public const string guidFWCodeGeneratorCmdSetString = "d0f876fa-46e9-4c4e-a536-88390dc5df69";

        public static readonly Guid guidFWCodeGeneratorCmdSet = new Guid(guidFWCodeGeneratorCmdSetString);
    };
}