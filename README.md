# LibraryManagermentSystem · 图书管理系统

WinForms 桌面客户端 + ASP.NET Core Web API 的图书管理 Demo。客户端不直连数据库，所有数据都走 HTTP 接口 —— 这也是这个仓库和早期「UI 直接连库」写法的分水岭。

## 目录结构

```
LibraryManagermentSystem/
├── Library.slnx              # 解决方案（8 个项目）
├── Library.UI/               # WinForms 客户端（net8.0-windows）
├── Library.WebAPI/           # Web API 入口（控制器、Session、CORS、鉴权过滤器）
├── Library.Service/          # EF Core 上下文、实体、业务服务、Migrations
├── Library.IService/         # 服务接口
├── Library.Model/            # 请求/响应模型
├── Library.DTO/              # 传输对象
├── Library.Common/           # 通用工具（ApiResult、MD5、CaptchaGen 封装）
└── LibraryAPI.Common/        # API 侧共享工具
```

分层与 `DriverExam` 系列一致：`UI → WebAPI → IService → Service → EF Core`，DTO 隔离传输结构，`Common` 放跨层工具。

## 技术栈

.NET 8 · ASP.NET Core · EF Core 8.0.22（**SQL Server**）· Swashbuckle 6.6.2 · CaptchaGen.NetCore 1.1.2（图形验证码）· WinForms（`net8.0-windows`）

## 功能

**图书管理**
- 书籍列表 / 按 ID 查详情
- 新增书籍（书名、分类、简介、作者、出版社、出版日期、价格、封面图）
- 编辑书籍
- 批量标记删除（软删除，`IsDeleted` 字段）

**分类管理**
- 分类列表 / 按书籍反查分类
- 新增、重命名、删除分类

**账号**
- 手机号 + 密码 + 图形验证码登录
- 注册（含短信验证码占位实现）
- 退出登录

**封面图**：客户端把图片转成 Base64 提交，服务端解码后写进运行目录下的 `images/`，文件名用 GUID，路径存 `Book.PicUrl`。

## 数据模型

所有实体继承 `Entity`：`Id` / `CreateDateTime` / `IsDeleted`。

| 实体 | 字段 |
| --- | --- |
| `Book` | `Name`、`TypeId`、`Type`、`Description`、`Author`、`Publisher`、`PublisherDate`、`Price`、`PicUrl` |
| `BookType` | `Name`、`Books` |
| `User` | `PhoneNum`、`PasswordSalt`、`PasswordHash` |

密码存储为 `MD5(PasswordSalt + password)`（`CommonHelper.CalcMD5`）。注意这是教学实现，明文 MD5 加盐不足以对抗离线爆破；要上生产请换 PBKDF2 / bcrypt / Argon2（对比参考同作者的 `AuthAPI` 项目，那里用的是 PBKDF2 + 16 字节随机盐）。

迁移历史：`Init` → `AddType` → `ExpandSize` → `Update-Lenth`。

## 接口一览

鉴权方式：**Session Cookie**（`Session["userId"]`）。需要登录的接口在方法上标 `[Authorized]`，由 `AuthorizedFilter` 统一校验；未登录返回 `{ Status: "error", ErrorMsg: "未登录" }`。

| 方法 | 路径 | 说明 |
| --- | --- | --- |
| GET | `/api/Book` | 书籍列表 |
| GET | `/api/Book/{id}/detail` | 书籍详情 |
| POST | `/api/Book` | 新增书籍 |
| POST | `/api/Book/edit/{id}` | 编辑书籍 |
| POST | `/api/Book/delete` | 批量软删除（Body 为 `int[]`） |
| GET | `/api/Type` | 分类列表 |
| POST | `/api/Type/{typeName}` | 新增分类 |
| POST | `/api/Type` | 编辑分类 |
| GET | `/api/Type/{id}/book` | 分类下的书籍 |
| GET | `/api/Type/{id}` | 按书籍 ID 查分类 |
| DELETE | `/api/Type/{id}` | 删除分类 |
| POST | `/api/User/login` | 登录 |
| POST | `/api/User/register` | 注册 |
| GET | `/api/User/logout` | 退出登录 |
| GET | `/api/User/verify-code` | 取图形验证码 |
| GET | `/api/User/send-sms/{phoneNum}` | 发送短信验证码（示例实现） |

统一返回 `Library.Common.ApiResult`。CORS 当前放开到 `AllowAnyOrigin`，仅适合本地调试。

## 运行

### 服务端

1. 准备 SQL Server，建库 `Lib`（或改 `Library.Service/LibContext.cs` 里的连接串）：

   ```
   Server=.;Database=Lib;Trusted_Connection=True;TrustServerCertificate=True
   ```

2. 建表并启动：

   ```bash
   dotnet restore
   dotnet ef database update --project Library.Service --startup-project Library.WebAPI
   dotnet run --project Library.WebAPI
   ```

   默认监听 `https://localhost:7220` / `http://localhost:5037`，`/swagger` 可看全部接口。

### 客户端（Windows）

`Library.UI/ApiUrls.cs` 里写死了 `https://localhost:7220/api/...`，先确保服务端跑在这个地址，然后：

```bash
dotnet run --project Library.UI
```

首次使用先注册（`RegisterForm`）→ 输入图形验证码 → 登录 → 主界面管理图书与分类。

## 已知问题

1. **服务端连接串硬编码**在 `Library.Service/LibContext.cs`，没有走 `appsettings.json` / 环境变量，换机器要改代码。
2. **`Book.PicUrl` 存的是服务端本地绝对路径**（`Path.Combine(Directory.GetCurrentDirectory(), "images", ...)`），客户端在另一台机器上取不到图；正确做法是存相对路径或对外 URL，由 API 单独提供图片接口。
3. **CORS 完全放开**（`AllowAnyOrigin`），且带 Session 的接口没有 CSRF 防护。
4. 短信验证码是占位实现，没有接真实网关。
5. `WeatherForecastController` 是模板遗留文件，可以删。

## 许可

个人学习项目，未附带开源许可文件；如需引用请先联系作者。
