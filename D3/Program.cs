var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
List<phone> repo = new List<phone>();
{
    new phone(1, "Xiaomi redmi mega pro 6g ultra special edition deluxe", "Ну супер крутой", 12000);
};

app.MapGet("/", () => repo);
app.MapPost("/add", (phone o) => repo.Add(o));
app.MapPut("/{id}", (int id, UpdateDTO dto) => 
{
    phone buffer = repo.Find(x => x.number == id);
    buffer.name = dto.name;
    buffer.description = dto.description;
    buffer.price = dto.price;
});
app.MapDelete("/delete/{id}", (int id) =>
{
    phone buffer = repo.Find(x => x.number == id);
    repo.Remove(buffer);
});
app.Run();
class phone
{
    public int number { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int price { get; set; }
    public phone(int number, string name, string description, int price)
    {
        this.number = number;
        this.name = name;
        this.description = description;
        this.price = price;
    }
}
record class UpdateDTO(string name, string description, int price);