using System;

using F10Y.T0004;
using F10Y.T0010;


namespace F10Y.T0013
{
    /// <summary>
    /// Test fixtures perform tests on test article instances.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is the first piece of a general testing framework methodology that works for both:
    /// <list type="number">
    /// <item>Functionality instance methods, and</item>
    /// <item>Service definitions.</item>
    /// </list>
    /// </para>
    /// <para>
    /// The actual test methods should be defined in an abstract type {X}TestFixture that is generic in the test article type,
    /// but that adds a restriction to the test article type in that it should implement an interface I{X}TestArticle.
    /// 
    /// The {X}TestFixture is not marked as a [TestClass], but does contain methods marked as [TestMethod]s.
    /// 
    /// And this {X}TestFixture/I{X}TestArticle pair coevolve together as tests in the test fixture are built to test methods from the test article.
    /// </para>
    /// 
    /// <para>
    /// The library implementing the {X}TestFixture is able to import lots value instances, especially expectations, and is very "heavy".
    /// 
    /// The I{X}TestArticle interface is simpler, and can go into a T## sub-library that is very "light".
    /// 
    /// This is the second piece of the general testing framework methodology.
    /// </para>
    /// 
    /// <para>
    /// The third and final piece is a library that implements an {X}TestFixture_For{Y} class that is a concrete (non-abstract) derivation from the abstract {X}TestFixture type,
    /// and an {X}TestArticle_For{Y} class that implements the I{X}TestArticle interface.
    /// 
    /// The {X}TestFixture_For{Y} class specifies the {X}TestArticle_For{Y} class as its type parameter,
    /// and the {X}TestArticle_For{Y} class implements the I{X}TestArticle interface by calling either:
    /// <list type="number">
    /// <item>Functionality instance methods to test them, or</item>
    /// <item>Service definition methods for a service definition.</item>
    /// </list>
    /// </para>
    /// <para>
    /// Note that for service definitions, those have their own test fixture framework methodology.
    /// However, the general framework test fixture can be re-used by implementing a service-definition specific test article,
    /// which in turn serves as the test fixture for some service-implementation.
    /// </para>
    /// </remarks>
    [TestFixtureMarker, UtilityTypeMarker]
    public abstract class TestFixtureBase<TTestArticle>
    {
        /// <summary>
        /// Allows inheritors to provide a test article instance.
        /// This instance may or may not have been used in previous tests, it is left ambiguous.
        /// This detail is left up to the eventual test fixture implementation.
        /// </summary>
        public abstract TTestArticle TestArticle { get; }
    }
}
