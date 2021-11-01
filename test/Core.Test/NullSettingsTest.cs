using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace NuGet.Test
{
    public class NullSettingsTest
    {
        public static object[][] WriteOperationsData = {
            new object[]{ (Action)(() => NullSettings.Instance.SetValue("section", "key", "value")), "SetValue" },
            new object[]{ (Action)(() => NullSettings.Instance.SetValues("section", new[] { new SettingValue("key", "value", false) })), "SetValues" },
            new object[]{ (Action)(() => NullSettings.Instance.SetNestedValues("section", "key", new[] { new KeyValuePair<string, string>("key1", "value1") })), "SetNestedValues" },
            new object[]{ (Action)(() => NullSettings.Instance.DeleteSection("section")), "DeleteSection" },
            new object[]{ (Action)(() => NullSettings.Instance.DeleteValue("section", "key")), "DeleteValue" },
        };

        [Theory]
        [MemberData(nameof(WriteOperationsData))]
        public void NullSettingsThrowsIfWriteOperationMethodsAreInvoked(Action throwsDelegate, string methodName)
        {
            // Act and Assert
            ExceptionAssert.Throws<InvalidOperationException>(throwsDelegate,
                String.Format("\"{0}\" cannot be called on a NullSettings. This may be caused on account of insufficient permissions to read or write to \"%AppData%\\NuGet\\NuGet.config\".", methodName));
        }
    }
}
