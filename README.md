# csharp-utr-tax-number
Validation and Generation of UTR tax numbers.

Supports net35, net40, net45 and netstandard20.

# Usage
## Validation
```
var validator = new Validator();
var result = validator.Validate(utr);
Assert.That(result.Equals(true));
```

## Generation
```
var generator = new Generator();
var utr = generator.Generate();

// with ditrict
var generator = new Generator("020"); // london district
var utr = generator.Generate();
```
