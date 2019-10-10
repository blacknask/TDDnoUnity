using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
   public class CoracaoTestes
    {
        [Test]
        public void ImagemPreenchimento0Recarregamento0()
        {

            Image image = new GameObject().AddComponent<Image>();
            image.fillAmount = 0;
            Coracao coracao = new Coracao(image);
            coracao.Recarregar(0);

            Assert.AreEqual(0, image.fillAmount);
        }
        [Test]
        public void ImagenPreenchimento0Recarregamento()
        {
            Image image = new GameObject().AddComponent<Image>();
            image.fillAmount = 0;
            Coracao coracao = new Coracao(image);
            coracao.Recarregar(1);

            Assert.AreEqual(0.25f, image.fillAmount);
        }
        private class Coracao
        {
            private const float PreenchimentoPedaco = 0.25f;
            private readonly Image image;

            public Coracao(Image image)
            {
                this.image = image;
            }

            internal void Recarregar(int pedacos)
            {
                this.image.fillAmount = pedacos * 0.25f;
            }
        }
    }
}
