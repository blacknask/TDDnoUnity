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
        public class TestesMetodoRecarga
        {
            private Image img;
            private Coracao cor;

            [SetUp]
            public void Config()
            {
                img = new GameObject().AddComponent<Image>();
                cor = new Coracao(img);
            }


            [Test]
            public void ImagemPreenchimento0Recarregamento0()
            {
                img.fillAmount = 0;
                cor.Recarregar(0);

                Assert.AreEqual(0, img.fillAmount);
            }
            [Test]
            public void ImagenPreenchimento025Recarregamento1()
            {
                img.fillAmount = 0.25f;
                cor.Recarregar(1);

                Assert.AreEqual(0.5f, img.fillAmount);
            }
            [Test]
            public void ImagenPreenchimento1Recarregamento1()
            {
                img.fillAmount = 1f;
                cor.Recarregar(1);

                Assert.AreEqual(1f, img.fillAmount);
            }

        }


        public class TestesMetodoDescarga
        {
            private Image img;
            private Coracao cor;

            [SetUp]
            public void Config()
            {
                img = new GameObject().AddComponent<Image>();
                cor = new Coracao(img);
            }

             [Test]
             public void ImagemPreenchimento1Descarregamento1()
             {
                img.fillAmount = 1.0f;
                cor.Decarregar(1);

                Assert.AreEqual(0.0f, img.fillAmount);
             }
             
            [Test]
            public void localExecaoMumeroNegativo()
            {
                Assert.Throws<ArgumentException>(() => cor.Decarregar (-1));
            }
        }
        

        public class Coracao
        {
            private const float PreenchimentoPedaco = 0.25f;
            private readonly Image image;

            public Coracao(Image image)
            {
                this.image = image;
            }


            public void Recarregar(int pedacos)
            {
                this.image.fillAmount += pedacos * 0.25f;
            }


            public void Decarregar(int pedacos)
            {
                if (pedacos < 0)
                    throw new ArgumentException("O argumento deve ser um valor positivo","pedacos");
                this.image.fillAmount -= pedacos * PreenchimentoPedaco;
            }
        }
    }
}
