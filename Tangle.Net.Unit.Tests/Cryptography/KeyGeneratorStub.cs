﻿namespace Tangle.Net.Unit.Tests.Cryptography
{
  using Tangle.Net.Cryptography;
  using Tangle.Net.Entity;

  /// <summary>
  /// The key generator stub.
  /// </summary>
  internal class KeyGeneratorStub : IKeyGenerator
  {
    #region Public Methods and Operators

    /// <summary>
    /// The get key for.
    /// </summary>
    /// <param name="address">
    /// The address.
    /// </param>
    /// <returns>
    /// The <see cref="IPrivateKey"/>.
    /// </returns>
    public IPrivateKey GetKeyFor(Address address)
    {
      return new PrivateKeyStub();
    }

    #endregion
  }
}