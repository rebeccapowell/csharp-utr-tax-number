# csharp-utr-tax-number
Validation and Generation of UTR tax numbers.

Supports net35, net40, net45 and netstandard20.

![Build Status](https://www.myget.org/BuildSource/Badge/powells?identifier=7125dea2-58d2-47c2-83f5-19f1b185bd2e)

Warning: The UTR generator is for testing purposes only. It generates UTR numbers that pass the UTR validation,
but they are not genuine and should not be used for fraudulent purposes.

Nuget: https://www.nuget.org/packages/Powell.UtrTaxNumberTools/1.0.1

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

# Prohibited Uses
You may only use the software for lawful purposes. You may not use the software: 

- In any way that breaches any applicable local, national or international law or regulation
- In any way that is unlawful or fraudulent or has any unlawful or fraudulent purpose or effect

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
