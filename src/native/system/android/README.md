# android Plugins

## 介绍

采用直接引入Java源码方式，当然也可以使用导入jar包或其他方式。

## 注意事项

+ 要覆盖UnityPlayer包名必须与项目包名保持一致。
+ Manifest必须放在Plugin/Android目录下才可以替换。
+ Unity调用Android代码非静态类对象时，类不能时Activity或Application类，如果要调用这些类对象，需通过静态函数获取对象实例进行调用。