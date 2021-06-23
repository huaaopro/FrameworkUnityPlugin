# Unity Plugins

## 介绍

Unity可以开发两种插件，Managed plugins和Native plugins。

Managed plugins 是托管式.NET插件，使用对应Unity的.NET版本进行开发。

Native plugins 平台相关的原生插件，可以访问操作系统的插件或者第三方的插件。

在Unity5之前，通过插件存放的目录来区分支持的目标平台；然而Unity5可以把插件放
在任何目录，通过Plugin Inspector设置相关属性就可以了，但为了兼容以前的版本，
Unity5也会支持插件存放的目录，进行默认的插件设置。

规则如下:

```
文件夹	                                                默认插件设置
Assets/**/Editor	                                    只兼容Editor
Assets/**/Editor/(x86 or x86_64 or x64)	                只兼容Editor，如果子文件夹存在，用于匹配目标CPU
Assets/Plugins/x86_64(or x64)	                        x64兼容
Assets/Plugins/x86	                                    x86兼容
Assets/Plugins/Android/(x86 or armeabi or armeabi-v7a)	只跟Android兼容，如果子文件夹存在，用于匹配目标CPU
Assets/Plugins/iOS	                                    只跟iOS兼容
```

## 插件分类

### 托管插件（Managed plugins）

通常情况下，我们直接使用脚本实现相关功能，然后由Unity编译成目标可执行文件。但有
时我们想在外部把脚本编译成DLL，然后放在Unity中使用。这个DLL就是这里所说的托管式
插件，兼容.NET二进制。

托管插件相对来说比较常见，也是项目开发中比较常见的方式，文章结尾的unity-plugins-development
项目也给出了简单的托管插件的案例，敬请参考。

### 原生插件（Native Plugins）

原生插件一般采用C,C++,Objective-C等等编写，Unity允许游戏代码来访问这些原生插件中的函数，
允许Unity和一些中间件库或者已有的C/C++进行整合和。

### C原生插件

这类插件是使用C或者是C++语言编写的插件，这类插件有点是兼容所有平台，集成方便，使用简单。重要的
案例如大家在游戏开发中使用tolua,slua,xlua插件都是基于这种方式插件。

### System原生插件

系统插件，顾名思义，就是和操作系统相关的插件，Unity引擎跨平台特性是其非常重要的特点，但是无论
跨平台做的如何突出，也总有一些系统特殊接口是引擎没有考虑接口，这些接口就需要编写原生系统插件进行
支持。

+ ios 系统插件

	使用Object-C开发的iOS库，支持iOS相关特性的插件，如震屏，手机电量，信号强度等。
  
+ android 系统插件
  
	使用Java开发的Android库，支持Android相关特性的插件，如震屏，手机电量，信号强度等。

## 插件实践

+ 托管插件
	- 插件源码: src/managed
	- 插件测试：sample/Assets/Scene/Managed/Managed.unity

+ 原生插件C
	- 插件源码: src/native/c
	- 插件测试：sample/Assets/Scene/Native/C.unity

+ 原生系统插件iOS
	- 插件源码: src/native/system/ios
	- 插件测试：sample/Assets/Scene/Native/System.unity

+ 原生系统插件Android
	- 插件源码: src/native/system/android
	- 插件测试：sample/Assets/Scene/Native/System.unity

## 注意事项

项目中C原生插件编译采用CMake插件进行编译，关于CMake介绍这里补充一下，相对来说，
CMake比make编译工具要复杂的多，中文的资料相对比较少，这里推荐几篇文章感兴趣的可
以阅读一下：

[CMake cmake 学习笔记(一，二，三)](https://my.oschina.net/chen0dgax/blog/151894)
和大多数资料相比，这篇写的更加的通俗易懂，如果大家还是觉得使用起来比较陌生，后面
会专门单独一个git项目演示CMake是如何实现扩平台编译的。

## 参考资料

+ [Unity Manual](https://docs.unity3d.com/Manual/UnityManual.html)
+ [Unity Plugins](https://docs.unity3d.com/Manual/Plugins.html)
+ [Building Plugins for iOS](https://docs.unity3d.com/Manual/PluginsForIOS.html)
+ [Building Plugins for Android](https://docs.unity3d.com/Documentation/Manual/PluginsForAndroid.html)
+ [Building Plugins for Desktop Platforms](https://docs.unity3d.com/Documentation/Manual/PluginsForDesktop.html)