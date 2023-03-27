> ## ⚠️ Deprecated ⚠️
>
> String loading has now been added to the game by default!
> [Click here for an example of how to use it.](ALTERNATIVE.md)
>
> The original readme is left below.

# WandererStringsLoader

📜 Simple mod resource for loading custom `wanderer_strings.xml` files in Mount & Blade: Bannerlord.

## Installation

Go to the [Releases](https://github.com/duniul/bannerlord-wanderer-strings-loader/releases) tab to
download the compiled .dll file.

All source code can be found in [`SubModule.cs`](SubModule.cs).

## Usage

To use it in your mod, drop `WandererStringsLoader.dll` into
`YourModuleDirectory\bin\Win64_Shipping_Client`. It will then automatically load any
`wanderer_strings*.xml` files in the loaded modules.

You also need to add it to the `SubModule.xml` file in your module, like this:

```xml
  <SubModules>
    <SubModule>
      <Name value="WandererStringsLoader"/>
      <DLLName value="WandererStringsLoader.dll"/>
      <SubModuleClassType value="WandererStringsLoader.Main"/>
      <Tags>
        <Tag key="DedicatedServerType" value="none" />
        <Tag key="IsNoRenderModeElement" value="false" />
      </Tags>
    </SubModule>
  </SubModules>
```
