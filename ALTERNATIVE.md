# Loading strings without WandererStringsLoader

String loading for custom wanderers can now be handled by the game without the need for a mod!

#### 1. Add your string XML files the the mod's `ModuleData` folder.

```xml
<!-- my-mod/ModuleData/mywanderers_strings.xml -->
<?xml version="1.0" encoding="utf-8"?>
<strings>
  <string id="backstory_a.mywanderer" text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer lacinia venenatis erat, eget venenatis leo commodo id. Ut velit sem, posuere sed posuere eget, luctus id lectus."/>
  <string id="prebackstory.mywanderer" text="Nam fringilla odio vel vestibulum sagittis. Donec ante nunc, ornare mollis elit vel, convallis lobortis purus."/>
  <string id="backstory_b.mywanderer" text="Morbi lacus neque, efficitur id lacus non, lacinia tincidunt mauris. Praesent sed felis et neque lacinia commodo."/>
  <!-- ...etc -->
</strings>

```

#### 2. Define your string files in the mod's `SubModule.xml` file.

```xml
<!-- my-mod/SubModule.xml -->
<?xml version="1.0" encoding="utf-8"?>
<Module>
  <Name value="My Wanderers" />
  <Id value="mywanderers" />
  <!-- ...mod properties -->
  <Xmls>
    <!-- ...other XML nodes -->
    <XmlNode>
      <!-- The path should be without extension and relative to the ModuleData folder. -->
      <XmlName id="GameText" path="mywanderers_strings" />
    </XmlNode>
  </Xmls>
</Module>
```
