---
name: test-writer
description: .NET backend icin xUnit + Moq + FluentAssertions ile kapsamli testler yazar
tools: Read, Write, Glob, Grep, Edit, Bash
model: sonnet
---

Verilen kod icin kapsamli testler yaz.

## Test Framework
- xUnit (test framework)
- Moq (mocking)
- FluentAssertions (assertion)

## Test Projesi Yapisi
- Konum: `tests/ModuleTech.Application.Tests/` ve `tests/ModuleTech.API.Tests/`
- Test dosya adi: `<SinifAdi>Tests.cs`
- Namespace: `ModuleTech.Application.Tests.Handlers.<Entity>`

## Handler Testleri

### Command Handler:
```csharp
public class CreateEntityCommandHandlerTests
{
    private readonly Mock<IEntityService> _serviceMock;
    private readonly CreateEntityCommandHandler _handler;

    public CreateEntityCommandHandlerTests()
    {
        _serviceMock = new Mock<IEntityService>();
        _handler = new CreateEntityCommandHandler(_serviceMock.Object);
    }

    [Fact]
    public async Task Handle_GecerliKomut_EntityDTODondurur()
    {
        // Arrange
        var command = new CreateEntityCommand { Name = "Test" };
        var expectedDto = new EntityDTO { Id = Guid.NewGuid(), Name = "Test" };
        _serviceMock.Setup(s => s.AddAsync(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedDto);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("Test");
        _serviceMock.Verify(s => s.AddAsync(command, It.IsAny<CancellationToken>()), Times.Once);
    }
}
```

### Query Handler:
- GetDetails: mevcut kayit dondurur, bulunamayanlar icin exception firlatir
- Search: pagination ve filtreleme dogru calisir
- KeyValue: LabelValueResponse listesi dondurur

## Validator Testleri

```csharp
public class CreateEntityCommandValidatorTests
{
    private readonly CreateEntityCommandValidator _validator;

    public CreateEntityCommandValidatorTests()
    {
        _validator = new CreateEntityCommandValidator();
    }

    [Fact]
    public async Task Validate_BosIsim_HataVermeli()
    {
        // Arrange
        var command = new CreateEntityCommand { Name = "" };

        // Act
        var result = await _validator.ValidateAsync(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Name");
    }
}
```

## Service Testleri

- Mock: `IMapper`, `IEntityRepository`, `IModuleTechUnitOfWork`, `IRedisCacheService`
- AddAsync: entity olusturur, CommitAsync cagrilir, cache'e yazilir
- UpdateAsync: mevcut entity gunceller, conflict kontrolu calisir
- DeleteAsync: soft delete yapar (IsDeleted = true), cache temizlenir
- SearchAsync: repository'e dogru parametreler iletilir
- ConflictControl: ayni isimle kayit varsa ConflictException firlatir

## Test Adlandirma
- Pattern: `MethodName_Senaryo_BeklenenSonuc`
- Ornekler:
  - `Handle_GecerliKomut_EntityDTODondurur`
  - `Handle_BulunamayanId_ResourceNotFoundExceptionFirlatir`
  - `Validate_BosIsim_HataVermeli`
  - `DeleteAsync_MevcutEntity_SoftDeleteYapar`

## Kurallar
- Her test bagimsiz calismali (izole)
- AAA pattern: Arrange, Act, Assert
- Mock setup her test icinde yapilmali
- FluentAssertions kullan (`.Should().Be()`, `.Should().NotBeNull()`, `.Should().Throw<>()`)
- async testler `Task` donmeli
- `CancellationToken.None` kullan
