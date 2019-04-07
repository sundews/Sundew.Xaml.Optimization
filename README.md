# Sundew.Xaml.Optimization

## Implementing an optimizer:
1. Create a new .NET framework 4.6.1 project.
2. Reference Sundew.Xaml.Optimization e.g. via Nuget.
3. Create the optimizer class and implement IXamlOptimizer. Currently WPF, UWP and Xamarin.Forms are supported and each optimizer have to indicate which platforms they support.
4. If the optimization requires code to work at runtime, this will have to be included in an additional dll.
5. Build and distribute dll(s)
6. If distributing via Nuget, remember it should be a tools package for the optimizer and lib packages for runtime code.

## Usage sample:
Refer to the sample: https://github.com/hugener/Sundew.Xaml.Optimizer.Sample

## Implementing constructors for IXamlOptimizer:
Constructors in xaml optimizer are flexible as they can accept some parameters and different variations of these:
* XamlPlatformInfo can be passed into the constructor and contains some basic information about the current xaml platform.
* Additionally, a JObject (Json.NET) is accepted. This represents the settings for a particular optimizer in the sxo-settings.json file.
Instead of JObject a custom type serializing the settings is also permitted.
The parameters can occur in any order or only include the one or the other and the constructor with the most parameters will be used.

## Returning additional files:
When returning a successful optimization, additional files may also be passed to the result, which allows for creating more advanced optimizations.
