using Repositorio.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o servi�o UsuarioRepository
builder.Services.AddSingleton<UsuarioRepository>();

// Adicionando o suporte para controllers e views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura��o para tratamento de exce��es em ambiente de produ��o
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Redirecionamento HTTP para HTTPS
app.UseHttpsRedirection();

// Servindo arquivos est�ticos (como CSS, imagens, etc.)
app.UseStaticFiles();

// Habilitando roteamento
app.UseRouting();

// Configurando autoriza��o (se houver)
app.UseAuthorization();

// Mapeando rota padr�o para os controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

// Executando a aplica��o
app.Run();