using System;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;

namespace Core.Specifications;
public class CategoryByNameSpecification(string name) : BaseSpecification<Category>(x => x.CategoryName == name)
{

}
