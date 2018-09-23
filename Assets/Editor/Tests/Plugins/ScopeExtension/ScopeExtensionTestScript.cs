using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using ScopeExtensions;

public class ScopeExtensionTestScript {

    [Test]
    public void AboutAlso() {
        // Use the Assert class to test conditions.
        var obj = new Object();
        var result = obj.Also(it => Assert.AreEqual(obj, it));
        Assert.AreEqual(obj, result);
    }

    [Test]
    public void AboutLet() {
        // Use the Assert class to test conditions.
        var obj = new Object();
        var result = obj.Let(it => {
            Assert.AreEqual(obj, it);
            return true;
        });
        Assert.IsTrue(result);
    }
}
