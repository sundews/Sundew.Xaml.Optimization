# Sundew.Xaml.Optimization

## Implementing an optimizer:
1. Create a new .NET Standard 2.0 project.
2. Reference Sundew.Xaml.Optimization e.g. via Nuget.
3. Create the optimizer class and implement IXamlOptimizer. Currently WPF, Maui, Avalonia, WinUI, UWP and Xamarin.Forms are supported and each optimizer have to indicate which platforms they support.
4. If the optimization requires code to work at runtime, this will have to be included in an additional dll or package dependency.
5. Build and distribute dll(s), e.g. via NuGet


## Usage sample:
Refer to the sample: https://github.com/sundews/Sundew.Xaml.Optimizer.Sample

## Implementing IXamlOptimizer:
The [IXamlOptimizer](https://github.com/sundews/Sundew.Xaml.Optimization/blob/master/Source/Sundew.Xaml.Optimization/IXamlOptimizer.cs) interface should be implemented to create a xaml optimizer.

### Constructors:
Constructors in xaml optimizer can accept an optional settings object:
* Additionally, a JObject (Json.NET) is accepted. This represents the settings for a particular optimizer in the "settings.sxos" file.
Instead of JObject, a custom type, deserializing the settings is also permitted.

### Optimize method:
The Optimize method is called gets called with the following information:
* A list of all xaml files in the project as XDocument.
* [XamlPlatformInfo](https://github.com/sundews/Sundew.Xaml.Optimization/blob/master/Source/Sundew.Xaml.Optimization/Xml/XamlPlatformInfo.cs) contains some basic information about the current xaml platform. 
* [ProjectInfo](https://github.com/sundews/Sundew.Xaml.Optimization/blob/master/Source/Sundew.Xaml.Optimization/ProjectInfo.cs), which contains information about the project, e.g. target framework, output type, assembly name etc..

The Optimize method should return an [OptimizationResult](https://github.com/sundews/Sundew.Xaml.Optimization/blob/master/Source/Sundew.Xaml.Optimization/OptimizationResult.cs) containing the results of the optimization.
When rewriting the xaml, it is recommended to not change the line ordering, because the optimized Xaml will be compiled and after compilation not be visible to the programmer (unless using a decompiler).

### Xaml Namespaces:
When modifying Xaml it might be necessary to add xmlns declarations. This can be done via the [XNamespaceInserter](https://github.com/sundews/Sundew.Xaml.Optimization/blob/master/Source/Sundew.Xaml.Optimization/Xml/XNamespaceInserter.cs) class, which ensures that prefixes are unique and that the same namespace is not added multiple times.

### Returning additional files:
When returning a successful optimization, additional files may also be passed to the result, which allows for creating more advanced optimizations, e.g. with generated code.

### Implementing a Xaml Analyzer:
An [IXamlOptimizer](https://github.com/sundews/Sundew.Xaml.Optimization/blob/master/Source/Sundew.Xaml.Optimization/IXamlOptimizer.cs) can implement code analysis, in this case it does not modify the xaml, but returns a list of diagnostics in the OptimizationResult, which are then reported to MSBuild.

### Packaging the optimizer:
Generally, an optimizer can be packaged in any way, e.g. as a NuGet package.
When packaging the following rules are recommended:
* Merge assemblies into a single dll to avoid assembly resolution issues. Example with [ILRepack](https://github.com/sundews/Sundew.Xaml.Optimizers.Wpf/blob/master/Source/Sundew.Xaml.Optimizers.Wpf/ILRepack.targets): 
* Do not merge Sundew.Xaml.Optimization.dll, System.*dlls as they are already loaded.
* The analyzer should be packaged into the "build" folder
* If the optimizer requires runtime code, this should be packaged into the "lib" folder or provided as a NuGet package dependency.

## Sample optimizers:
* [ResourceDictionaryOptimizer](https://github.com/sundews/Sundew.Xaml.Optimizers.Wpf/blob/master/Source/Sundew.Xaml.Optimizers.Wpf/ResourceDictionary/ResourceDictionaryOptimizer.cs)

* [FreezeResourceOptimizer](https://github.com/sundews/Sundew.Xaml.Optimizers.Wpf/blob/master/Source/Sundew.Xaml.Optimizers.Wpf/Freezing/FreezeResourceOptimizer.cs)