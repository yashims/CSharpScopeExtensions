# Introduction
CSharpScopeExtensions inspiration from Kotlin's scope functions. The Instance pass to arguments lambda myself.

Scope function useful keep clealy code.

# Installation

1. Download unitypackage from [Release Page](https://github.com/yashims/CSharpScopeExtensions/releases) and import it.

2. Copy source code to your project.
  * Scope functions are simple. You would understand it quickly.

# Exsample

## Let
### Not use Let
```csharp
Transform t = GetComponent<Transform>();
float distanceXFromGrandParent = t.parent.transform.localPosition.x + t.localPosition.x;
```

### Use Let
```csharp
float distanceXFromGrandParent = GetComponent<Transform>().Let((it) =>
{
    return it.parent.transform.localPosition.x + it.localPosition.x;
});
```
* Function scope not make dirty by component temporary variable.
* 'Let' can use for like LINQ's 'Select'.

## Also
### Not use Also
```csharp
Transform t1 = GetComponent<Transform>();
Quaternion q1 = new Quaternion();
q1.x = 0;
q1.y = 0;
q1.x = 0;
t1.rotation = q1;
```

### Use Also
```csharp
Transform t2 = GetComponent<Transform>().Also((it) =>
{
    it.rotation = new Quaternion().Also((that) =>
    {
        that.x = 0;
        that.y = 0;
        that.z = 0;
    });
});
```
* It clear what about processing.

# Things impossible
I gave up transplant 'With', 'Run' and 'Apply'.
Because, I have not idea that way to change 'this' context in lambda.
