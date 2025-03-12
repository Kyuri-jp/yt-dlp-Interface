# yt-dlp Interface
yt-dlpの簡単な動作をコンソール上で簡単に行えます

# Feature
# Applications
|Application|Discription|
|----|----|
|OptionSelector|yt-dlpの引数を選択し、引数を生成します|
|Preset|Option Selectorで生成された引数を保存し、後から呼び出すことができます|
|Client|yt-dlpのアップデート等を行うことができます|

## OptionSelector
### 対応している引数
#### Audio
- --audio-format (format)
- --embed-metadata
- --embed-thumbnail
#### Video
- -f (videoQuality)[ext=(videoFormat)]+(audioQuality)[ext=(audioFormat)]
- -S vcodec:(codec)

# Using
起動後、コンソールに以下のアプリケーションを選択してください

exitを入力するとそのアプリケーションを終了します
> [!NOTE]
> 値を入力する際は基本的にアルファベットの大文字、小文字の区別はありません
## OptionSelector
### Commands
|Command|Discription|
|----|----|
|Enter|現在選択した引数で確定します|
|Mode|Audio,Videoのモードを切り替えます|
|Make|引数を作成します|
|Get|現在の引数を表示します|
|Custom|任意の引数を指定します|
#### Make
helpを入力すると設定できる引数の一覧が表示されます。

引数を選択するとその引数の詳細が表示され、フォーマットやコーデックを設定できます。
> VideoFormatを選択するとmp4やwebmなどのフォーマットを選択できます
##### Video Mode
|設定できる引数|種類|
|----|----|
|VideoFormat|3gp,flv,m4a,mp4,webm|
|AudioFormat|acc,mp3,ogg,wav,m4a|
|Codec|av01,vp9_2,vp9,h265,h264,mp8,h263,theora|
|Quality|best,worse|

##### Audio Mode
|設定できる引数|種類|
|----|----|
|Format|acc,mp3,ogg,wav,m4a|
|Thumbnail|y/n|
|Metadata|y/n|
## Preset
|Command|Discription|
|----|----|
|Create|プリセットを作成します|
|Load|プリセットを読み込みます|
|Get|プリセットをすべて表示します|

### Create
OptionSelectorで設定した引数を保存することができます

## Client
|Command|Discription|
|----|----|
|Update|yt-dlpのアップデートを行います|
|Version|yt-dlpのバージョンを表示します|

> [!CAUTION]
> yt-dlpは環境変数`Path`から自動的に検索されます
> 
> ツールを使用する前にyt-dlp.exeが保存されているディレクトリを登録してください