# WpfDiffView
Control extracted from [GitSharp.Demo](https://github.com/henon/GitSharp.Demo)

## Sample

![demo app](https://github.com/stanac/WpfDiffView/raw/master/screenshot.png)

``` xml
<!-- Left and Right are string properties in view model -->
<wpfDiffView:DiffView LeftText="{Binding Left}"
                      RightText="{Binding Right}" />
```

## Install from Nuget

```
Install-Package WpfDiffView
```