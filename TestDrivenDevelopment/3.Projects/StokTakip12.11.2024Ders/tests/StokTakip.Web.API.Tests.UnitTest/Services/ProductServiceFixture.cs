using AutoMapper;
using GenericRepository;
using NSubstitute;
using StokTakip.WebAPI.Repositories;
using StokTakip.WebAPI.Services;

namespace StokTakip.WebAPI.Tests.UnitTest;
public sealed class ProductServiceFixture
{
    public IProductRepository productRepo = Substitute.For<IProductRepository>();
    public IUnitOfWork uow = Substitute.For<IUnitOfWork>();
    public IMapper mapper = Substitute.For<IMapper>();
    public readonly ProductService productService;
    public ProductServiceFixture()
    {
        productService = new(productRepo, uow, mapper);
    }
}