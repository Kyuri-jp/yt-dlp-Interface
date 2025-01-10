# yt-dlp Interface
yt-dlpの簡単な動作をコンソール上で簡単に行えます

# Feature
## Preset
yt-dlpの引数のプリセットを作成できます

## Easy Arguments Selector
いくつかの質問に答えるだけで自動的に引数が生成されます
### 対応している引数
#### Audio
- --audio-format (format)
- --embed-metadata
- --embed-thumbnail
#### Video
- -f (videoQuality)[ext=(videoFormat)]+(audioQuality)[ext=m4a]
- -S vcodec:(codec)

> [!CAUTION]
> yt-dlpは環境変数`Path`から自動的に検索されます
> 
> ツールを使用する前にyt-dlp.exeが保存されているディレクトリを登録してください

# How to Use
## Preset
### Create
1. *Do you use any presets? (y/n)* -> n
2. *Do you make new preset or modify any preset?* -> y
3. *Plase enter preset name.* -> Enter preset name.
4. Answer argument questions.

### Use
1. *Do you use any presets? (y/n)* -> y
2. *Select any preset.* -> Enter preset name.
3. *Please enter url* -> Enter source url.
