namespace Hqub.Esenin.App.Tools
{
    public static class InitDatabase
    {
        private static Model.MyEntityContext Context { get; set; }

        public static void Fill(Model.MyEntityContext ctx)
        {
            if(ctx == null)
                return;

            Context = ctx;

            ДобавитьСтих_ЧерныйЧеловек();
            ДобавитьСтих_ДоСвиданьяДругМойДоСвиданья();
            ДобавитьСтих_ЯУсталымТакимЕщеНеБыл();

            Context.SaveChanges();
        }

        #region 1925

        private static void ДобавитьСтих_ЧерныйЧеловек()
        {
            var poem = Context.Poems.Create();
            poem.Title = "Черный человек";
            poem.Year = 1925;

            Context.Poems.Add(poem);
        }

        private static void ДобавитьСтих_ДоСвиданьяДругМойДоСвиданья()
        {
            var poem = Context.Poems.Create();
            poem.Title = "До свиданья, друг мой, до свиданья";
            poem.Year = 1925;

            var quatrain1 = Context.Quatrains.Create();
            quatrain1.Order = 1;
            quatrain1.Text = Cl(
@"
До свиданья, друг мой, до свиданья.
Милый мой, ты у меня в груди.
Предназначенное расставанье
Обещает встречу впереди.");

            var quatrain2 = Context.Quatrains.Create();
            quatrain2.Order = 2;
            quatrain2.Text = Cl(@"
До свиданья, друг мой, без руки, без слова,
Не грусти и не печаль бровей,-
В этой жизни умирать не ново,
Но и жить, конечно, не новей.");

            poem.Quatrains.Add(quatrain1);
            poem.Quatrains.Add(quatrain2);

            Context.Poems.Add(poem);
        }

        #endregion

  

        #region 1923

        private static void ДобавитьСтих_ЯУсталымТакимЕщеНеБыл()
        {
            var poem = Context.Poems.Create();
            poem.Title = "Я усталым таким еще не был";
            poem.Year = 1923;

            var quatrain1 = Context.Quatrains.Create();
            quatrain1.Order = 1;
            quatrain1.Text = Cl(
@"
Я усталым таким еще не был
В эту серую морозь и слизь
Мне приснилось рязанское небо
И моя непутевая жизнь.");

            var quatrain2 = Context.Quatrains.Create();
            quatrain2.Order = 2;
            quatrain2.Text = Cl(
@"
Много женщин меня любило.
Да и сам я любил не одну.
Не от этого ль темная сила
Приучила меня к вину.");

            var quatrain3 = Context.Quatrains.Create();
            quatrain3.Order = 3;
            quatrain3.Text = Cl(
@"
Бесконечные пьяные ночи
И в разгуле тоска не впервь!
Не с того ли глаза мне точит
Словно синие листья червь?");

            var quatrain4 = Context.Quatrains.Create();
            quatrain4.Order = 4;
            quatrain4.Text = Cl(
@"
Не больна мне ничья измена,
И не радует легкость побед,
Тех волос золотое сено
Превращается в серый цвет,");

            var quatrain5 = Context.Quatrains.Create();
            quatrain5.Order = 5;
            quatrain5.Text = Cl(
@"
Превращается в пепел и воды,
Когда цедит осенняя муть.
Мне не жаль вас, прошедшие годы,
Ничего не хочу вернуть.");

            var quatrain6 = Context.Quatrains.Create();
            quatrain6.Order = 6;
            quatrain6.Text = Cl(
@"
Я устал себя мучить бесцельно.
И с улыбкою странной лица
Полюбил я носить в легком теле
Тихий свет и покой мертвеца.");

            var quatrain7 = Context.Quatrains.Create();
            quatrain7.Order = 7;
            quatrain7.Text = Cl(
@"
И теперь даже стало не тяжко
Ковылять из притона в притон,
Как в смирительную рубашку
Мы природу берем в бетон.");

            var quatrain8 = Context.Quatrains.Create();
            quatrain8.Order = 8;
            quatrain8.Text = Cl(
@"
И во мне, вот по тем же законам,
Умиряется бешеный пыл.
Но и все ж отношусь я с поклоном
К тем полям, что когда-то любил.");

            var quatrain9 = Context.Quatrains.Create();
            quatrain9.Order = 9;
            quatrain9.Text = Cl(
@"
В те края, где я рос под кленом,
Где резвился на желтой траве,—
Шлю привет воробьям и воронам
И рыдающей в ночь сове.");

            var quatrain10 = Context.Quatrains.Create();
            quatrain10.Order = 10;
            quatrain10.Text = Cl(
@"
Я кричу им в весенние дали:
«Птицы милые, в синюю дрожь
Передайте, что я отскандалил,—
Пусть хоть ветер теперь начинает
Под микитки дубасить рожь».");

            poem.Quatrains.Add(quatrain1);
            poem.Quatrains.Add(quatrain2);
            poem.Quatrains.Add(quatrain3);
            poem.Quatrains.Add(quatrain4);
            poem.Quatrains.Add(quatrain5);
            poem.Quatrains.Add(quatrain6);
            poem.Quatrains.Add(quatrain7);
            poem.Quatrains.Add(quatrain8);
            poem.Quatrains.Add(quatrain9);
            poem.Quatrains.Add(quatrain10);

            Context.Poems.Add(poem);
        }

        #endregion

        private static string Cl(string v)
        {
            return v.Trim();
        }
    }
}
