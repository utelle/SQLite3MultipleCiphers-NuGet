# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [2.3.4] - 2026-05-06

### Changed

- Based of [SQLite3 Multiple Ciphers 2.3.4](https://github.com/utelle/SQLite3MultipleCiphers/releases/tag/v2.3.4) and [SQLite 3.53.1](https://sqlite.org/releaselog/3_53_1.html)

### Fixed

- Fixed _SQLite3MC_ issue [#232](https://github.com/utelle/SQLite3MultipleCiphers/issues/232) - Zero out one-time-keys (for cipher schemes `chacha20`, `aegis`, and `ascon128`) after encrypt/decrypt operation
- Resolved _SQLite3MC_ issue [#233](https://github.com/utelle/SQLite3MultipleCiphers/issues/233) - Add support for specifying plaintext header size in non-legacy mode of the _SQLCipher_ cipher scheme. This option was supported only for legacy mode version 4 (legacy=4), but there is no reason to not support it for non-legacy mode.

## [2.3.3] - 2026-04-10

### Changed

- Based of [SQLite3 Multiple Ciphers 2.3.3](https://github.com/utelle/SQLite3MultipleCiphers/releases/tag/v2.3.3) and [SQLite 3.53.0](https://sqlite.org/releaselog/3_53_0.html)

### Fixed

- Fixed _SQLite3MC_ issue [#230](https://github.com/utelle/SQLite3MultipleCiphers/issues/230) - Cipher data structures are not nullified securely on freeing

## [2.3.2] - 2026-03-19

### Changed

- Based of [SQLite3 Multiple Ciphers 2.3.2](https://github.com/utelle/SQLite3MultipleCiphers/releases/tag/v2.3.2) and [SQLite 3.51.3](https://sqlite.org/releaselog/3_51_3.html)

### Fixed

- Fixed _SQLite3MC_ issue [#228](https://github.com/utelle/SQLite3MultipleCiphers/issues/228) - Function `sqlite3mc_cipher_name` not thread-safe

> [!CAUTION]
> For applications using _SQLite_ in a **multi-threaded** environment an **upgrade is highly recommended**, because issue #228 could lead to runtime errors.

## [2.3.1] - 2026-03-14

### Changed

- Based of [SQLite3 Multiple Ciphers 2.3.1](https://github.com/utelle/SQLite3MultipleCiphers/releases/tag/v2.3.1) and [SQLite 3.51.3](https://sqlite.org/releaselog/3_51_3.html)
- Downgrade to _SQLite 3.51.3_ due to withdrawal of _SQLite 3.52.0_

## [2.3.0] - 2026-03-08

### Changed

- Based of [SQLite3 Multiple Ciphers 2.3.0](https://github.com/utelle/SQLite3MultipleCiphers/releases/tag/v2.3.0) and [SQLite 3.52.0](https://sqlite.org/releaselog/3_52_0.html)

## [2.2.7] - 2026-01-10

### Changed

- Based of [SQLite3 Multiple Ciphers 2.2.7](https://github.com/utelle/SQLite3MultipleCiphers/releases/tag/v2.2.7) and [SQLite 3.51.2](https://sqlite.org/releaselog/3_51_2.html)

## [2.2.6] - 2025-11-30

### Changed

- First public release of the _SQLite3MC_ NuGet packages
- Based of [SQLite3 Multiple Ciphers 2.2.6](https://github.com/utelle/SQLite3MultipleCiphers/releases/tag/v2.2.6) and [SQLite 3.51.1](https://sqlite.org/releaselog/3_51_1.html)


[Unreleased]: ../../compare/v2.3.4...HEAD
[2.3.4]: ../../compare/v2.3.3...v2.3.4
[2.3.3]: ../../compare/v2.3.2...v2.3.3
[2.3.2]: ../../compare/v2.3.1...v2.3.2
[2.3.1]: ../../compare/v2.3.0...v2.3.1
[2.3.0]: ../../compare/v2.2.7...v2.3.0
[2.2.7]: ../../compare/v2.2.6...v2.2.7
[2.2.6]: ../../compare/v2.2.6...v2.2.6
