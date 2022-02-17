using System;

namespace Decorator
{
  class decorators
  {
    static void Main(string[] args)
    {
      ICookie cookie = new Cookie();
      ICookie chocolate = new ChocolateCookie(cookie);
      ICookie marshmellow = new MarshmellowCookie(chocolate);
      Console.WriteLine(marshmellow.GetCookie());
      Console.ReadLine();
    }
  }

  interface ICookie
  {
    string GetCookie();
  }

  class Cookie : ICookie
  {
    public string GetCookie()
    {
      return "Tienes una galleta sin toppings";
    }
  }

  class CookieDecorator: ICookie
  {
    private ICookie _cookie;

    public CookieDecorator(ICookie cookie)
    {
      _cookie = cookie;
    }
    public virtual string GetCookie()
    {
      return _cookie.GetCookie();
    }
  }

  class ChocolateCookie : CookieDecorator
  {
    public ChocolateCookie(ICookie cookie) : base(cookie)
    { }

    public override string GetCookie()
    {
      string type = base.GetCookie();
      type += "\r\nAñadiste chispas de chocolate";
      return type;
    }
  }

  class MarshmellowCookie : CookieDecorator
  {
    public MarshmellowCookie(ICookie cookie) : base(cookie)
    { }

    public override string GetCookie()
    {
      string type = base.GetCookie();
      type += "\r\nAñadiste pequeños marshmellows";
      return type;
    }
  }
}
