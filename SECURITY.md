# Security Policy

## Security Reports

This repository is part of the [SQLite3MultipleCiphers](https://github.com/utelle/SQLite3MultipleCiphers) distribution pipeline for _NuGet_ packages.

It provides a thin binding layer and packaging logic that combines prebuilt native binaries produced by the [SQLite3MultipleCiphers-cb](https://github.com/utelle/SQLite3MultipleCiphers-cb) repository into _NuGet_ packages.

If you believe you have discovered a security vulnerability in this repository, please use [GitHub’s private vulnerability reporting](https://github.com/utelle/SQLite3MultipleCiphers-NuGet/security/advisories/new) feature for this repository.

Security vulnerabilities related to cryptographic functionality, SQLite behavior, or core implementation must be [reported in the main repository](https://github.com/utelle/SQLite3MultipleCiphers/security/policy).

All security classification, severity assessment, and coordinated disclosure are handled in the main repository.

## Scope Clarification

This repository includes:

- A lightweight binding layer (compatible to _SQLitePCLRaw_)
- NuGet packaging and metadata generation
- Integration of prebuilt native binaries from the [SQLite3MultipleCiphers-cb](https://github.com/utelle/SQLite3MultipleCiphers-cb) repository

It does not implement encryption algorithms or database engine logic.

## Supply Chain Considerations

While this repository does not implement cryptographic functionality, it is part of the software supply chain and distribution trust boundary.

Therefore, security concerns may include:

- Tampering or corruption of packaged binaries
- Incorrect or malicious packaging of dependencies
- Build or publishing pipeline issues affecting distributed NuGet packages
- Dependency confusion or registry-level attacks affecting package integrity

Such issues will be triaged and handled in coordination with the main project repository.

## Reporting Guidance

If you are unsure which repository is appropriate, please report the issue in the [main](https://github.com/utelle/SQLite3MultipleCiphers/security/policy) repository for proper coordination and classification.
