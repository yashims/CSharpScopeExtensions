# Introduction
CSharpScopeExtensions inspiration from Kotlin's scope functions. The Instance pass to arguments lambda myself.

Scope function useful keep clealy code.

# Installation

## For Unity
Download unitypackage from [Release Page](https://github.com/yashims/CSharpScopeExtensions/releases) and import it.

## For Other or Unity
Copy source code to your project.
* Scope functions are simple. You would understand it quickly.
* Wellcome PULL REQUEST :beer:

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

```csharp
string say(string comment)
{
    return comment?.Let(it => $"I said: {it}") ?? "";
}
```
* If you use C#6.x can use for nullable unwrapping with combination with safe navigation operator.
* **Perfectly** null-safe in lambda.

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
I gave up porting 'With', 'Run' and 'Apply'. Because, I don't have idea that way to change 'this' context in lambda.
