// See https://aka.ms/new-console-template for more information
using Logic;
using Logic.Entities;

var show = new Event(GenerateSection.Generate(), GenerateVisitors.VisitorGenerate(), GenerateVisitors.GroupGenerate());

