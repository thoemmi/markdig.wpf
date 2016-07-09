﻿// Copyright (c) 2016 Nicolas Musset. All rights reserved.
// This file is licensed under the MIT license. 
// See the LICENSE.md file in the project root for more information.

using Markdig.Syntax;

namespace Markdig.Renderers.Xaml
{
    /// <summary>
    /// A XAML renderer for a <see cref="ListBlock"/>.
    /// </summary>
    /// <seealso cref="Xaml.XamlObjectRenderer{T}" />
    public class ListRenderer : XamlObjectRenderer<ListBlock>
    {
        protected override void Write(XamlRenderer renderer, ListBlock listBlock)
        {
            renderer.EnsureLine();

            renderer.Write("<List");
            if (listBlock.IsOrdered)
            {
                renderer.Write(" MarkerStyle=\"Decimal\"");

                if (listBlock.OrderedStart != null && (listBlock.DefaultOrderedStart != listBlock.OrderedStart))
                {
                    renderer.Write(" StartIndex=\"").Write(listBlock.OrderedStart).Write("\"");
                }
            }
            else
            {
                renderer.Write(" MarkerStyle=\"Disc\"");
            }
            renderer.WriteLine(">");

            foreach (var item in listBlock)
            {
                var listItem = (ListItemBlock)item;

                renderer.EnsureLine();
                renderer.Write("<ListItem>");
                renderer.WriteChildren(listItem);
                renderer.WriteLine("</ListItem>");
                
            }
            renderer.WriteLine("</List>");
        }
    }
}
