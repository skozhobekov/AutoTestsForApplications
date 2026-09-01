using apitest.Interfaces;

IShape shape = new Circle{Radius = 2};
IShape shape2 = new Rectangle(){Width = 2,  Height = 2};
ILogger logger = new ConsoleLogger();
ILogger logger2 = new FileLogger();
ShapeService shapeService = new ShapeService();
LoggerService  loggerService = new LoggerService();

Console.WriteLine(shapeService.CalculateArea(shape));
Console.WriteLine(shapeService.CalculateArea(shape2));

loggerService.WriteLog(logger2, "Hello World");


