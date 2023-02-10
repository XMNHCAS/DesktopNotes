# DesktopNotes

---

## 简述

本软件为Windows桌面便笺，支持Win7及以上版本的Windows系统。本软件参照Win10系统附带的便笺程序进行开发，并在其基础上添加了本地存储、窗体置顶等功能。

---

## 开发语言及框架
+ 开发语言：C#
+ 开发平台：Windows
+ .NET框架：.NET Framework 4.5
+ 开发框架：WPF

---

## 支持功能

1. 创建简易便笺。

2. 便笺字体格式化，包括加粗、斜体等。

3. 修改软件主题色。

4. 多便笺创建，每个便笺支持单独主题色。

5. 支持窗体置顶模式，开启此模式后，便笺的窗体将保持置顶，不会被其它应用程序覆盖，此模式支持单个便笺单独设置。

6. 支持本地笔记存储模式，若开启此模式，则会在此软件目录下自动创建一个sqlite数据库，便笺内容将会保存至此数据库中，如需使用其它数据库，可根据实际需要修改源码的数据库连接部分。

---

### 更新日志

> 2023-02-09：基础功能开发完成，支持主题色切换、本地笔记存储等。
> 2023-02-10: 完成便笺列表基础功能，修改数据库字段类型。