using Repositorio.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o serviço UsuarioRepository
builder.Services.AddSingleton<UsuarioRepository>();

// Adicionando o suporte para controllers e views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração para tratamento de exceções em ambiente de produção
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Redirecionamento HTTP para HTTPS
app.UseHttpsRedirection();

// Servindo arquivos estáticos (como CSS, imagens, etc.)
app.UseStaticFiles();

// Habilitando roteamento
app.UseRouting();

// Configurando autorização (se houver)
app.UseAuthorization();

// Mapeando rota padrão para os controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

// Executando a aplicação
app.Run();