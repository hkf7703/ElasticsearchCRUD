﻿using System.Collections.Generic;
using ElasticsearchCRUD.Model;
using ElasticsearchCRUD.Utils;

namespace ElasticsearchCRUD.ContextAddDeleteUpdate.IndexModel.SettingsModel.Analyzers
{
	public class StandardAnaylzer : AnalyzerBase
	{
		private int _maxTokenLength;
		private bool _maxTokenLengthSet;
		private string _stopwords;
		private bool _stopwordsSet;
		private List<string> _stopwordsList;
		private bool _stopwordsListSet;

		public StandardAnaylzer(string name)
		{
			AnalyzerSet = true;
			Name = name.ToLower();
			Type = DefaultAnalyzers.Standard;
		}

		/// <summary>
		/// A list of stopwords to initialize the stop filter with. Defaults to the english stop words.
		/// Use stopwords: _none_ to explicitly specify an empty stopword list.
		/// </summary>
		public List<string> StopwordsList
		{
			get { return _stopwordsList; }
			set
			{
				_stopwordsList = value;
				_stopwordsListSet = true;
			}
		}

		public string Stopwords
		{
			get { return _stopwords; }
			set
			{
				_stopwords = value;
				_stopwordsSet = true;
			}
		}

		/// <summary>
		/// max_token_length
		/// The maximum token length. If a token is seen that exceeds this length then it is discarded. Defaults to 255.
		/// </summary>
		public int MaxTokenLength
		{
			get { return _maxTokenLength; }
			set
			{
				_maxTokenLength = value;
				_maxTokenLengthSet = true;
			}
		}

		public override void WriteJson(ElasticsearchCrudJsonWriter elasticsearchCrudJsonWriter)
		{
			base.WriteJsonBase(elasticsearchCrudJsonWriter, WriteValues);
		}

		private void WriteValues(ElasticsearchCrudJsonWriter elasticsearchCrudJsonWriter)
		{
			JsonHelper.WriteValue("type", Type, elasticsearchCrudJsonWriter);
			JsonHelper.WriteValue("max_token_length", _maxTokenLength, elasticsearchCrudJsonWriter, _maxTokenLengthSet);

			if (_stopwordsListSet)
			{
				JsonHelper.WriteListValue("stopwords", _stopwordsList, elasticsearchCrudJsonWriter, _stopwordsListSet);
			}
			else
			{
				JsonHelper.WriteValue("stopwords", _stopwords, elasticsearchCrudJsonWriter, _stopwordsSet);
			}
		}
	}
}