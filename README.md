# [Blockchain Network & Blockchain Client + Xamarin Mobile Wallet App + QR Code based Payment Shop](https://github.com/dpedwards/dotnet-core-blockchain-advanced)

[![LICENSE](https://img.shields.io/badge/license-MIT-lightgrey.svg)](https://raw.githubusercontent.com/dpedwards/dotnet-core-blockchain-advanced/master/LICENSE)
[![.NET Core](https://img.shields.io/badge/dotnet%20core-%3E%3D%202.2-blue.svg)](https://dotnet.microsoft.com/download)
[![Tip Me via PayPal](https://img.shields.io/badge/PayPal-tip%20me-green.svg?logo=paypal)](https://www.paypal.me/dare2101)

A blockchain is a growing list of records, called blocks. The blocks are linked using cryptography and each block contains a cryptographic hash of the previous block, transaction data, and a timestamp. 

## Solutions

- BlockChain
- BlockchainPaymentShop
- XamarinWallet
- ProxyServer

## Notable features

- cryptography 
- process of creating blocks
- process of chaining blocks 
- network & mining
- wallet generator
- make transaction
- view transactions
- wallet transactions
- QR Code generator
- unlock videos with mobile wallet by scanning QR Code and paying cryptocurrency on blockchain
- etc.

## Note

There are two solutions in this repository:
- Blockchain is listening on port :43211
  - Fixed blockchain public key for easy testing: 18jp31DcT3n5vsYHGVhhQa2qsvEve4EUoQ
  - Fixed blockchain private key for easy testing: L3aq7WPiSois3N7GxTr6ZSXMNdfbAZWNebiYvKK5hAUBCijk95rL

- Blockchain Client is listening on port :5000 

:sparkles: See what`s new in the [CHANGELOG](CHANGELOG.md).

**If you enjoy this project, please consider [supporting me](https://www.paypal.me/dare2101) for developing and maintaining it.**

[![Support via PayPal](https://cdn.rawgit.com/twolfson/paypal-github-button/1.0.0/dist/button.svg)](https://www.paypal.me/dare2101)


## Blockchain Client Pictures 

Wallet Generator:
![](BlockChain/images/Blockchain%20Client_Wallet%20Generator.png)

Make Transaction:
![](BlockChain/images/Blockchain%20Client_Make%20Transaction.png)

![](BlockChain/images/Blockchain%20Client_Make%20Transaction2.png)

![](BlockChain/images/Blockchain%20Client_Make%20Transaction3.png)

View Transactions:
![](BlockChain/images/Blockchain%20Client_View%20Transactions.png) 

Wallet Transactions:
![](BlockChain/images/Blockchain%20Client_Wallet%20Transactions.png) 


## Blockchain Pictures 

Mine:
![](BlockChain/images/Blockchain%20Frontend_Mine.png)

![](BlockChain/images/Blockchain%20Frontend_Mine2.png)

Add Node:
![](BlockChain/images/Blockchain%20Frontend_Configure.png)

Blockchain Overview:
![](BlockChain/images/Blockchain%20Frontend_CoinBase.png)


## Usage

For detailed instructions on how to configure, customize, add/migrate content, and more read the [project`s documentation](https://github.com/dpedwards/dotnet-core-blockchain-advanced/docs/quick-start-guide/).

---

## Contributing

Having trouble working with the project? Found a typo in the documentation? Interested in adding a feature or [fixing a bug](https://github.com/dpedwards/dotnet-core-blockchain-advanced/issues)? Then by all means [submit an issue](https://github.com/dpedwards/dotnet-core-blockchain-advanced/issues/new) or [pull request](https://help.github.com/articles/using-pull-requests/). If this is your first pull request, it may be helpful to read up on the [GitHub Flow](https://guides.github.com/introduction/flow/) first.

### Pull Requests

When submitting a pull request:

1. Clone the repo.
2. Create a branch off of `master` and give it a meaningful name (e.g. `my-awesome-new-feature`).
3. Open a pull request on GitHub and describe the feature or fix.

project documentation and demo pages can be found in the [`/docs`](docs) if submitting improvements, typo corrections, etc.

---

## Credits

### Creator

**Davain Pablo Edwards**

- <https://soon.com>
- <https://twitter.com/d_p_edwards>
- <https://github.com/dpedwards>

### Requirements

- [Visual Studio](https://visualstudio.microsoft.com/de/vs/)


### Other:

- [Microsoft.NETCore.App](https://dotnet.microsoft.com/)
- [NBitcoin](https://github.com/MetacoSA/NBitcoin)
- [Newtonsoft.Json](https://www.newtonsoft.com/json)


---

## License

MIT License

Copyright (c) 2019 Davain Pablo Edwards

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
