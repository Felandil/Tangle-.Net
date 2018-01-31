﻿namespace Tangle.Net.Unit.Tests.Cryptography
{
  using System.Diagnostics;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  using Tangle.Net.Cryptography;
  using Tangle.Net.Entity;

  /// <summary>
  /// The address generator test.
  /// </summary>
  [TestClass]
  public class AddressGeneratorTest
  {
    #region Fields

    /// <summary>
    /// The seed one.
    /// </summary>
    private readonly Seed seedOne = new Seed("TESTVALUE9DONTUSEINPRODUCTION999999GFDDCPFIIEHBCWFN9KHRBEIHHREFCKBVGUGEDXCFHDFPAL");

    /// <summary>
    /// The seed two.
    /// </summary>
    private readonly Seed seedTwo = new Seed("TESTVALUE9DONTUSEINPRODUCTION99999DCZGVEJIZEKEGEEHYE9DOHCHLHMGAFDGEEQFUDVGGDGHRDR");

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The test get multiple addresses.
    /// </summary>
    [TestMethod]
    public void TestGetMultipleAddresses()
    {
      var generator = new AddressGenerator(this.seedTwo);

      var st = new Stopwatch();
      st.Start();
      var addresses = generator.GetAddresses(0, 3);
      Assert.AreEqual("FNKCVJPUANHNWNBAHFBTCONMCUBC9KCZ9EKREBCJAFMABCTEPLGGXDJXVGPXDCFOUCRBWFJFLEAVOEUPY", addresses[0].Value);
      Assert.AreEqual("MSYILYYZLSJ99TDMGQHDOBWGHTBARCBGJZE9PIMQLTEXJXKTDREGVTPA9NDGGLQHTMGISGRAKSLYPGWMB", addresses[1].Value);
      Assert.AreEqual("IIREHGHXUHARKVZDMHGUUCHZLUEQQULLEUSJHIIBWFYZIZDUFTOVHAWCKRJXUZ9CSUVLTRYSUGBVRMTOW", addresses[2].Value);

      var a = st.ElapsedMilliseconds / 1000;

      addresses = generator.GetAddresses(10, 3);
      Assert.AreEqual("BPXMVV9UPKBTVPJXPBHHOJYAFLALOYCGTSEDLZBHNFMGEHREBQTRIPZAPREANPMZJNZZNCDIUFOYYGGFY", addresses[0].Value);
      Assert.AreEqual("RUCZQJWKXVDIXTLHHOKGMHOV9AKVDBG9HUQHPWNZUNKJNFVMULUSLKFJGSTBSNJMRYSJOBVBQSKVXISZB", addresses[1].Value);
      Assert.AreEqual("FQAKF9XVCLTBESJKWCHFOCTVABYEEJP9RXUVAEUWENFUUQK9VCHFEORHCYDUJQHNUDWNRDUDZTUGKHSPD", addresses[2].Value);
    }

    /// <summary>
    /// The test get single address.
    /// </summary>
    [TestMethod]
    public void TestGetSingleAddress()
    {
      var generator = new AddressGenerator(this.seedOne);

      var address = generator.GetAddress(0);
      Assert.AreEqual("DLEIS9XU9V9T9OURAKDUSQWBQEYFGJLRPRVEWKN9SSUGIHBEIPBPEWISSAURGTQKWKWNHXGCBQTWNOGIY", address.Value);
      Assert.AreEqual(2, address.SecurityLevel);

      var addressTwo = generator.GetAddress(10);
      Assert.AreEqual("XLXFTFBXUOOHRJDVBDBFEBDQDUKSLSOCLUYWGLAPR9FUROUHPFINIUFKYSRTFMNWKNEPDZATWXIVWJMDD", addressTwo.Value);
      Assert.AreEqual(10, addressTwo.KeyIndex);
    }

    /// <summary>
    /// The test security level higher than default.
    /// </summary>
    [TestMethod]
    public void TestSecurityLevelHigherThanDefault()
    {
      var generator = new AddressGenerator(this.seedOne, SecurityLevel.High);

      var addresses = generator.GetAddresses(0, 3);
      Assert.AreEqual("BGHTGOUKKNTYFHYUAAPSRUEVN9QQXFOGVCH9Y9BONWXUBDLSKAWEOFZIVMHXBAYVPGDZEYCKNTUJCLPAX", addresses[0].Value);
      Assert.AreEqual("EGMRJEUIYFUGWAIXXZCHCZUVUUYITICVHDSHCQXGFHJIVDCLTI9ZVRIKRLZQWW9CPOIXVDCBAHVGLUHI9", addresses[1].Value);
      Assert.AreEqual("ENPSARVJZGMMPWZTAIRHADEOZCEVIFNJWSZQHNEIRVEVI9GYMFNEOGNUYCPGPSEFCSDHUHOQKDPVGDKYC", addresses[2].Value);
    }

    /// <summary>
    /// The test security level lower than default.
    /// </summary>
    [TestMethod]
    public void TestSecurityLevelLowerThanDefault()
    {
      var generator = new AddressGenerator(this.seedOne, SecurityLevel.Low);

      var addresses = generator.GetAddresses(0, 3);
      Assert.AreEqual("KNDWDEEWWFVZLISLYRABGVWZCHZNZLNSEJXFKVGAUFLL9UMZYEZMEJB9BDLAASWTHEKFREUDIUPY9ICKW", addresses[0].Value);
      Assert.AreEqual("CHOBTRTQWTMH9GWFWGWUODRSGPOJOIVJUNIQIBZLHSWNYPHOD9APWJBMJMGLHFZENWFKDYWHX9JDFXTAB", addresses[1].Value);
      Assert.AreEqual("YHTOYQUCLDHAIDILFNPITVPYSTOCFAZIUNDYTRDZCVMVGZPONPINNVPJTOAOKHHZWLOKIZPVASTOGAKPA", addresses[2].Value);
    }

    #endregion
  }
}